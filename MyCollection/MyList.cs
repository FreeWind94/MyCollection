using System;
using System.Collections;
using System.Collections.Generic;

namespace MyCollection 
{
    //доносвязный список
    class MyList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Узел односвязного списка. Хранит данные типа "T" и ссылку на следующий элемент.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class Node<T>
        {
            public T Data { get; set; }
            /// <summary>
            /// Ссылка на следующий узел
            /// </summary>
            public Node<T> Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }

            public override string ToString()
            {
                return Data.ToString();
            }
        }

        /*  Для того чтобы управлять односвязным списком, достаточно хранить ссылку на его первый узел. 
            Но иногда полезно иметь ссылку на последний и текуший узел, а так же количество узлов. Эта информация обязана быть приватной, её нельзя изменять из вне,
            но порой полезно иметь доступ к чтению так что стоит добавить деттеры, которые будут возвращять данные из этих узлов, но не сами узлы.
            (Люблю поговорить сам с собой)
         */
        private Node<T> firstNode;
        private Node<T> lastNode;
        //private Node<T> currentNode;
        private int count;
        public T First { get => firstNode.Data; }
        public T Last { get => lastNode.Data; }
        //public T Current { get => currentNode.Data; }
        public int Count { get => count; }

        /// <summary>
        /// Инициализация пустого списка
        /// </summary>
        public MyList()
        {
            firstNode = lastNode = null;
            count = 0;
        }

        /// <summary>
        /// Свойство true, если список пуст
        /// </summary>
        public bool IsEmpty { get => count == 0; }

        /// <summary>
        /// Добавляет данные в конец списка
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            // инициализация нового узла
            Node<T> newNode = new Node<T>(data);
            // если список пуст добавляется первый узел
            if(IsEmpty)
            {
                firstNode = newNode;
                //currentNode = newNode;
            }
            else
            {
                // иначе узел добовляется в конец списка
                lastNode.Next = newNode;
            }
            lastNode = newNode;
            count++;
        }
        
        /// <summary>
        /// Очистка списка
        /// </summary>
        public void Clear()
        {
            // удаление реализовано самым простым методом в надежде, что сборщик мусора справиться с этой задачей сам
            firstNode = null;
            //currentNode = null;
            lastNode = null;
            count = 0;
        }

        
        public override string ToString()
        {
            string result = "";
            Node<T> currentNode = firstNode;
            while (currentNode != null)
            {
                result += currentNode.ToString() + Environment.NewLine;
                currentNode = currentNode.Next;
            }

            return result;
        }

        /*TODO: 
         * - поиск 
         * - склеивание двух списков
         */
        
        /// <summary>
        /// Удаление элемента из списка (если есть несколько элементов data, удаляется только первый по порядку)
        /// </summary>
        /// <param name="data">удаляемый элемент</param>
        /// <returns>true, если удаление элемента прошло успешно</returns>
        public bool Remove(T data)
        {
            Node<T> currentNode = firstNode;
            Node<T> previousNode = null;

            while (currentNode != null)
            {
                // обработка узла
                if(currentNode.Data.Equals(data))
                {
                    // ветка удаления узла
                    if(previousNode == null)
                    {
                        // удаляется первый узел
                        firstNode = firstNode.Next;

                        // проверка стал ли список пустым (на случай если список состоял из одного узла)
                        if(firstNode == null)
                        {
                            lastNode = null;
                        }
                    }
                    else
                    {
                        // удаляется средний или последний узел
                        previousNode.Next = currentNode.Next;

                        // если currentNode был полседним узлом, то теперь им должен быть previousNode
                        if(currentNode.Next == null)
                        {
                            lastNode = previousNode;
                        }
                    }
                    // узел успешно удалён
                    count--;
                    return true;
                }

                // переход к следующему узлу
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            return false;
        }

        //
        //возможность достать элемент по номеру
        /// <summary>
        /// Возращает номер первого элемента data в списке (если его нет, возращает -1)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int IndexOf(T data)
        {
            Node<T> currentNode = firstNode;
            int index = 0;
            while(currentNode != null)
            {
                if(currentNode.Data.Equals(data))
                {
                    return index;
                }
                index++;
                currentNode = currentNode.Next;
            }

            return -1;
        }

        public T this [int index]
        {
            get
            {
                if (index < 0 || index >= count) throw new ArgumentOutOfRangeException("index");
                Node<T> currentNode = firstNode;
                int indexCounter = 0;
                while(true)
                {
                    if(index == indexCounter++)
                    {
                        return currentNode.Data;
                    }
                    currentNode = currentNode.Next;
                }
            }
            set
            {
                if (index < 0 || index >= count) throw new ArgumentOutOfRangeException("index");
                Node<T> currentNode = firstNode;
                int indexCounter = 0;
                while (true)
                {
                    if (index == indexCounter++)
                    {
                        currentNode.Data = value;
                        return;
                    }
                    currentNode = currentNode.Next;
                }
            }
        }

        //
        // реализация интерфейса IEnumerable<T>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> currentNode = firstNode;
            while(currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
