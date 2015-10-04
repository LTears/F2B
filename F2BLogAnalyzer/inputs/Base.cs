﻿#region Imports
using System;
using System.Collections.Generic;
using System.Reflection;

#endregion

namespace F2B.inputs
{
    public abstract class BaseInput
    {
        #region Fields
        protected EventQueue equeue;
        #endregion

        #region Properties
        public string InputName { get; private set; }
        public string InputType { get; private set; }
        public string SelectorName { get; private set; }
        public string Processor { get; private set; }
        public string Name
        {
            get { return string.Concat(InputName, "/", SelectorName); }
        }
        public LoginStatus Status { get; private set; }
        #endregion

        #region Constructors
        public BaseInput(InputElement input, SelectorElement selector, EventQueue queue)
            : base()
        {
            InputName = input.Name;
            InputType = input.Type;
            SelectorName = selector.Name;
            Processor = selector.Processor;

            switch (selector.Login)
            {
                case "success": Status = LoginStatus.SUCCESS; break;
                case "failure": Status = LoginStatus.FAILURE; break;
                default: Status = LoginStatus.UNKNOWN; break;
            }

            equeue = queue;
        }
        #endregion

        #region Methods
        public abstract void Start();
        public abstract void Stop();
        #endregion
    }
}
