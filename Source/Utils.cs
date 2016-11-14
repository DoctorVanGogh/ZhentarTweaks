﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ZhentarTweaks
{
	public class Utils
	{
		public static Func<TValue> GetStaticFieldAccessor<TObject, TValue>(string fieldName)
		{
			var fieldInfo = typeof(TObject).GetField(fieldName, Detours.UniversalBindingFlags);
			var member = Expression.Field(null, fieldInfo);
			var lambda = Expression.Lambda(typeof(Func<TValue>), member);
			var compiled = (Func<TValue>)lambda.Compile();
			return compiled;
		}
	}
}
