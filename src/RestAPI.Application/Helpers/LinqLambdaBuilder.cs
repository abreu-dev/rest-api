using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace RestAPI.Application.Helpers
{
    public static class LinqLambdaBuilder
    {
        private static readonly string LikeCharacter = "*";

        public static string RemoveLikeCharacter(string text)
        {
            if (text.StartsWith(LikeCharacter))
            {
                text = text[1..];
            }

            if (text.EndsWith(LikeCharacter))
            {
                text = text[0..^1];
            }

            return text;
        }

        public static IQueryable<T> ApplyFilter<T>(IQueryable<T> source, string propertyName, string propertyValue)
        {
            if (propertyValue.StartsWith(LikeCharacter) && propertyValue.EndsWith(LikeCharacter))
            {
                var formatedValue = RemoveLikeCharacter(propertyValue);
                var predicate = Like<T>(propertyName, formatedValue.ToLower());
                source = source.Where(predicate);
            }
            else if (propertyValue.StartsWith(LikeCharacter))
            {
                var formatedValue = RemoveLikeCharacter(propertyValue);
                var predicate = EndsWith<T>(propertyName, formatedValue.ToLower());
                source = source.Where(predicate);
            }
            else if (propertyValue.EndsWith(LikeCharacter))
            {
                var formatedValue = RemoveLikeCharacter(propertyValue);
                var predicate = StartsWith<T>(propertyName, formatedValue.ToLower());
                source = source.Where(predicate);
            }
            else
            {
                var predicate = Equal<T>(propertyName, propertyValue.ToLower());
                source = source.Where(predicate);
            }

            return source;
        }

        public static Expression<Func<T, bool>> Equal<T>(string propertyName, string propertyValue)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
            Expression propertyExpression = BuildExpressionProperty<T>(propertyName, parameterExpression, true);
            ConstantExpression constantExpression = Expression.Constant(propertyValue, typeof(string));
            BinaryExpression equalExpression = Expression.Equal(propertyExpression, constantExpression);

            return Expression.Lambda<Func<T, bool>>(equalExpression, parameterExpression);
        }

        public static Expression<Func<T, bool>> Like<T>(string propertyName, string propertyValue)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
            Expression propertyExpression = BuildExpressionProperty<T>(propertyName, parameterExpression, true);
            MethodInfo methodInfo = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            ConstantExpression constantExpression = Expression.Constant(propertyValue, typeof(string));
            MethodCallExpression containsExpression = Expression.Call(propertyExpression, methodInfo, constantExpression);

            return Expression.Lambda<Func<T, bool>>(containsExpression, parameterExpression);
        }

        public static Expression<Func<T, bool>> StartsWith<T>(string propertyName, string propertyValue)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
            Expression propertyExpression = BuildExpressionProperty<T>(propertyName, parameterExpression, true);
            MethodInfo methodInfo = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
            ConstantExpression constantExpression = Expression.Constant(propertyValue, typeof(string));
            MethodCallExpression containsExpression = Expression.Call(propertyExpression, methodInfo, constantExpression);

            return Expression.Lambda<Func<T, bool>>(containsExpression, parameterExpression);
        }

        public static Expression<Func<T, bool>> EndsWith<T>(string propertyName, string propertyValue)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
            Expression propertyExpression = BuildExpressionProperty<T>(propertyName, parameterExpression, true);
            MethodInfo methodInfo = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
            ConstantExpression constantExpression = Expression.Constant(propertyValue, typeof(string));
            MethodCallExpression containsExpression = Expression.Call(propertyExpression, methodInfo, constantExpression);

            return Expression.Lambda<Func<T, bool>>(containsExpression, parameterExpression);
        }

        private static Expression BuildExpressionProperty<T>(this string propertyName, ParameterExpression parameterExpression, bool toLower)
        {
            Expression propertyExpression = parameterExpression;

            foreach (var property in propertyName.Split('.'))
            {
                propertyExpression = Expression.Property(propertyExpression, property);
            }

            if (toLower)
            {
                propertyExpression = Expression.Call(propertyExpression, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
            }

            return propertyExpression;
        }
    }
}
