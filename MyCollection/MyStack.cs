using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyCollection
{
    class MyStack<T> : IEnumerable<T>
    {
        /// <summary>
        /// Узел стека.
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

        
        //Peek
        public MyStack()
        {
            firstNode = null;
            Count = 0;
        }

        /*  В стек реализуем припомоши односвязного списка 
         *  (в теории можно было бы прис от него отнаследовать 
         *  или сделать общий класс, но я не уверен что точно 
         *  знаю как это реализовать). Чтобы реализовать функции стека припомоши 
         *  списка, достаточно ссылки на первый узел и счётчика количества узлов.
         */
        private Node<T> firstNode;
        public int Count { get; private set; }

        public bool IsEmpty { get => Count == 0; }

        /// <summary>
        /// Добавить данные в стек
        /// </summary>
        /// <param name="Data"></param>
        public void Push(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.Next = firstNode;
            firstNode = newNode;
            Count++;
        }

        /// <summary>
        /// Достать данные из стека
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            // нельзя ничего достать из пустого стека
            if (IsEmpty) throw new InvalidOperationException("Стек пустой");

            Node<T> result = firstNode;
            firstNode = firstNode.Next;
            Count--;
            return result.Data;
        }

        /// <summary>
        /// Показать данные стека не доставая их (мои комментарии божественны)
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            // нельзя показать того чего нет
            if (IsEmpty) throw new InvalidOperationException("Стек пустой");

            return firstNode.Data;
        }

        //
        // реализация интерфейса IEnumerable<T>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> currentNode = firstNode;
            while (currentNode != null)
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
