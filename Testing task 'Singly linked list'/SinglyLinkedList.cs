using System;
using System.Collections;
using System.Collections.Generic;

namespace Testing_task__Singly_linked_list_
{
    class Node<U>
    {
        public U data;
        public Node<U> next;
        public Node(U Data)
        {
            data = Data;
            next = null;
        }
    }
    class SinglyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        public int Count { get; private set; } = 0;
        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (_head == null)
            {
                _head = newNode;
                Count = 1;
                return;
            }
            Node<T> lastNode = GetLastNode();
            lastNode.next = newNode;
            Count++;
        }
        private Node<T> GetLastNode()
        {
            Node<T> LastNode = _head;
            while (LastNode.next != null)
                LastNode = LastNode.next;
            return LastNode;
        }
        public void Insert(int index, T data)
        {
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException();
            else if (index == Count)
            {
                Add(data);
                return;
            }
            Node<T> newNode = new Node<T>(data);
            if (index == 0)
            {
                newNode.next = _head;
                _head = newNode;
            }
            else
            {
                Node<T> prevNode = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    prevNode = prevNode.next;
                }
                newNode.next = prevNode.next;
                prevNode.next = newNode;
            }
            Count++;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            else if (index == 0)
                _head = _head.next;
            else
            {
                Node<T> prevNode = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    prevNode = prevNode.next;
                }
                prevNode.next = prevNode.next.next;
            }
            Count--;
        }
        public T GetByIndex(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            else if (index == 0)
                return _head.data;
            Node<T> temp = _head.next;
            for (int i = 1; i < index; i++)
            {
                temp = temp.next;
            }
            return temp.data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
