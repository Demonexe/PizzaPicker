using _148103_148214.PizzaPicker.CORE;
using System.Linq.Expressions;

namespace _148103_148214.PizzaPicker.Services
{
    public class QueryBuilder<T> where T : class
    {
        public QueryBuilder()
        {
            _parameter = Expression.Parameter(typeof(T), "p");
        }
        public QueryBuilder<T> OnProperty(string propertyName)
        {
            _memExp = Expression.Property(_parameter, propertyName);
            return this;
        }

        public QueryBuilder<T> AddOperation(QueryBuilderOperation operation)
        {
            BinaryExpression localBinExp = null;
            MethodCallExpression localMethodExp = null;
            switch (operation)
            {
                case QueryBuilderOperation.Equal:
                    {
                        localBinExp = Expression.Equal(_memExp, _constantExp);
                        break;
                    }
                case QueryBuilderOperation.Contains:
                    {
                        localMethodExp = Expression.Call(_memExp, "Contains", null, _constantExp);
                        break;
                    }
                case QueryBuilderOperation.Less:
                    {
                        localBinExp = Expression.LessThan(_memExp, _constantExp);
                        break;
                    }
                case QueryBuilderOperation.Greater:
                    {
                        localBinExp = Expression.GreaterThan(_memExp, _constantExp);
                        break;
                    }
                case QueryBuilderOperation.NotEqual:
                    {
                        localBinExp = Expression.NotEqual(_memExp, _constantExp);
                        
                        break;
                    }
                case QueryBuilderOperation.And:
                    {
                        Expression firstExp = _binExp1 == null ? _methodCall1 : _binExp1;
                        Expression secondExp = (firstExp == _binExp1 ? (_methodCall1 == null ? _binExp2 : _methodCall1) 
                            : _methodCall2);
                        localBinExp = Expression.And(firstExp, secondExp);
                        _binExp1 = localBinExp;
                        _binExp2 = null;
                        _methodCall1 = null;
                        _methodCall2 = null;
                        return this;

                    }
                case QueryBuilderOperation.Or:
                    {
                        Expression firstExp = _binExp1 == null ? _methodCall1 : _binExp1;
                        Expression secondExp = (firstExp == _binExp1 ? (_methodCall1 == null ? _binExp2 : _methodCall1)
                            : _methodCall2);
                        localBinExp = Expression.Or(firstExp, secondExp);
                        _binExp1 = localBinExp;
                        _binExp2 = null;
                        _methodCall1 = null;
                        _methodCall2 = null;
                        return this;
                    }
            }
            if (localBinExp != null)
                SetNewBinaryExp(localBinExp);
            if (localMethodExp != null)
                SetNewMethodCallExp(localMethodExp);
            return this;
        }

        public QueryBuilder<T> AddValue(object value)
        {
            _constantExp = Expression.Constant(value);
            return this;
        }

        public QueryBuilder<T> AddExternalExpression(Expression extExpression, QueryBuilderOperation operation)
        {
            if (operation != QueryBuilderOperation.Or && operation != QueryBuilderOperation.And)
                return this;
            switch (operation)
            {
                case QueryBuilderOperation.And:
                    {
                        _binExp1 = Expression.And(_binExp1 == null ? _methodCall1 : _binExp1, extExpression);
                        _methodCall1 = null;
                        break;
                    }
                case QueryBuilderOperation.Or:
                    {
                        _binExp1 = Expression.Or(_binExp1 == null ? _methodCall1 : _binExp1, extExpression);
                        _methodCall1 = null;
                        break;
                    }
            }
            return this;
        }

        public Func<T, bool> Build()
        {
            Func<T, bool> result = null;
            if (_binExp1 == null && _methodCall1 != null)
                result = Expression.Lambda<Func<T, bool>>(_methodCall1, _parameter).Compile();
            else if(_binExp1 != null)
                result = Expression.Lambda<Func<T, bool>>(_binExp1, _parameter).Compile();
            return result;
        }

        public Expression GetExpression()
        {
            return _binExp1 == null ? _methodCall1 : _binExp1;
        }

        private void SetNewBinaryExp(BinaryExpression newExp)
        {
            if (_binExp1 == null)
            {
                _binExp1 = newExp;
                return;
            }
            _binExp2 = newExp;
        }

        private void SetNewMethodCallExp(MethodCallExpression newExp)
        {
            if (_methodCall1 == null)
            {
                _methodCall1 = newExp;
                return;
            }
            _methodCall2 = newExp;
        }

        private ParameterExpression _parameter;
        private MemberExpression _memExp;
        private ConstantExpression _constantExp;
        private BinaryExpression _binExp1;
        private BinaryExpression _binExp2;
        private MethodCallExpression _methodCall1;
        private MethodCallExpression _methodCall2;
    }
}
