﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Diagnostics;

namespace BulletSharp.SoftBody
{
    public class AlignedNoteArrayDebugView
    {
        private AlignedNoteArray _array;

        public AlignedNoteArrayDebugView(AlignedNoteArray array)
        {
            _array = array;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public Note[] Items
        {
            get
            {
                int count = _array.Count;
                Note[] array = new Note[count];
                for (int i = 0; i < count; i++)
                {
                    array[i] = _array[i];
                }
                return array;
            }
        }
    }

    public class AlignedNoteArrayEnumerator : IEnumerator<Note>
    {
        int _i;
        int _count;
        AlignedNoteArray _array;

        public AlignedNoteArrayEnumerator(AlignedNoteArray array)
        {
            _array = array;
            _count = array.Count;
            _i = -1;
        }

        public Note Current
        {
            get { return _array[_i]; }
        }

        public void Dispose()
        {
        }

        object System.Collections.IEnumerator.Current
        {
            get { return _array[_i]; }
        }

        public bool MoveNext()
        {
            _i++;
            return _i != _count;
        }

        public void Reset()
        {
            _i = 0;
        }
    }

    [Serializable, DebuggerTypeProxy(typeof(AlignedNoteArrayDebugView)), DebuggerDisplay("Count = {Count}")]
    public class AlignedNoteArray : IList<Note>
    {
        private IntPtr _native;

        internal AlignedNoteArray(IntPtr native)
        {
            _native = native;
        }

        public int IndexOf(Note item)
        {
            return btAlignedObjectArray_btSoftBody_Note_index_of(_native, item.Native);
        }

        public void Insert(int index, Note item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public Note this[int index]
        {
            get
            {
                if ((uint)index >= (uint)Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return new Note(btAlignedObjectArray_btSoftBody_Note_at(_native, index));
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Note item)
        {
            btAlignedObjectArray_btSoftBody_Note_push_back(_native, item.Native);
        }

        public void Clear()
        {
            btAlignedObjectArray_btSoftBody_Note_resizeNoInitialize(_native, 0);
        }

        public bool Contains(Note item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Note[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return btAlignedObjectArray_btSoftBody_Note_size(_native); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Note item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Note> GetEnumerator()
        {
            return new AlignedNoteArrayEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new AlignedNoteArrayEnumerator(this);
        }

        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern IntPtr btAlignedObjectArray_btSoftBody_Note_at(IntPtr obj, int n);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern int btAlignedObjectArray_btSoftBody_Note_index_of(IntPtr obj, IntPtr val);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btAlignedObjectArray_btSoftBody_Note_push_back(IntPtr obj, IntPtr val);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern void btAlignedObjectArray_btSoftBody_Note_resizeNoInitialize(IntPtr obj, int newSize);
        [DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
        static extern int btAlignedObjectArray_btSoftBody_Note_size(IntPtr obj);
    }
}