// This is a utility collection used for the pathfinder script.

namespace ExampleGame;

using System.Collections.Generic;
using Godot;

public class MinHeap<T>
{

    private List<T> _items;
    private readonly System.Func<T, float> _valueFunction;

    public MinHeap(System.Func<T, float> func, List<T> items = null)
    {
        _valueFunction = func;
        if (items != null)
        {
            _items = items;
            Heapify();
        }
        else
        {
            _items = new List<T>();
        }
    }

    public int Size => _items.Count;
    public bool IsEmpty => Size == 0;

    public T Peek()
    {
        if (_items.Count == 0)
        {
            throw new System.Exception("No items in heap!");
        }
        return _items[0];
    }

    public T Pop()
    {
        if (_items.Count == 0)
        {
            throw new System.Exception("No items in heap!");
        }
        T val = _items[0];

        if (_items.Count == 1)
        {
            _items.RemoveAt(0);
            return val;
        }

        _items[0] = _items[_items.Count - 1];
        _items.RemoveAt(_items.Count - 1);
        BubbleDown(0);

        return val;
    }

    public void Add(T item)
    {
        _items.Add(item);
        BubbleUp(_items.Count - 1);
    }

    private void Heapify()
    {
        for (int i = Size / 2; i >= 0; i--)
        {
            BubbleDown(i);
        }
    }

    private void BubbleUp(int idx)
    {
        if (idx == 0) return;
        int parentIdx = (idx - 1) / 2;
        T parentVal = _items[parentIdx];

        if (_valueFunction(_items[idx]) < _valueFunction(parentVal))
        {
            _items[parentIdx] = _items[idx];
            _items[idx] = parentVal;
        }

        BubbleUp(parentIdx);
    }

    private void BubbleDown(int idx)
    {
        if (idx >= _items.Count / 2) return;
        int leftChildIdx = 2 * idx + 1;
        int rightChildIdx = 2 * idx + 2;

        float iScore = _valueFunction(_items[idx]);
        float rScore = rightChildIdx < _items.Count ? _valueFunction(_items[rightChildIdx]) : Mathf.Inf;
        float lScore = _valueFunction(_items[leftChildIdx]);
        T iVal = _items[idx];

        if (iScore < lScore && iScore < rScore) return;
        if (lScore < iScore && lScore < rScore)
        {
            _items[idx] = _items[leftChildIdx];
            _items[leftChildIdx] = iVal;
            BubbleDown(leftChildIdx);
        }
        else if (rightChildIdx < _items.Count)
        {
            try
            {
                _items[idx] = _items[rightChildIdx];
                _items[rightChildIdx] = iVal;
                BubbleDown(rightChildIdx);
            } catch (System.Exception e)
            {
                GD.PrintErr(e);
            }
        }
    }

}