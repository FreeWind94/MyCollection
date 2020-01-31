using System;
using System.Collections.Generic;
using System.Text;

namespace MyCollection
{
    //доносвязный список
    class MyList<T>
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
        private Node<T> currentNode;
        private int count;
        public T First { get => firstNode.Data; }
        public T Last { get => lastNode.Data; }
        public T Current { get => currentNode.Data; }
        public int Count { get => count; }

        /// <summary>
        /// Инициализация пустого списка
        /// </summary>
        public MyList()
        {
            firstNode = lastNode = currentNode = null;
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
                currentNode = newNode;
            }
            else
            {
                // иначе узел добовляется в конец списка
                lastNode.Next = newNode;
            }
            lastNode = newNode;
            count++;
        }
        
        public override string ToString()
        {
            string result = "";
            currentNode = firstNode;
            while (currentNode != null)
            {
                result += currentNode.ToString() + Environment.NewLine;
                currentNode = currentNode.Next;
            }

            return result;
        }
    }
}
