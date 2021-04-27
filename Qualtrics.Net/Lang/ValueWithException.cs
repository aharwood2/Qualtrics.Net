using System;
using System.Collections.Generic;
using System.Text;

namespace Qualtrics.Net.Lang
{
    public class ValueWithException<V, E>
    {
        private readonly V value;
        private readonly E exception;
        private readonly bool hasValue;

        public ValueWithException(V left)
        {
            value = left;
            hasValue = true;
        }

        public ValueWithException(E right)
        {
            exception = right;
            hasValue = false;
        }

        public T Match<T>(Func<V, T> leftFunc, Func<E, T> rightFunc)
            => hasValue ? leftFunc(value) : rightFunc(exception);

        public static implicit operator ValueWithException<V, E>(V left) => new ValueWithException<V, E>(left);

        public static implicit operator ValueWithException<V, E>(E right) => new ValueWithException<V, E>(right);
    }
}
