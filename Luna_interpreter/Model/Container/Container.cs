﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna_interpreter.Model.Container
{
    public static class Container
    {
        public static Stack<object> operationStack = new Stack<object>();

        static Container()
        {
            operationStack.Clear();
        }
    }
}