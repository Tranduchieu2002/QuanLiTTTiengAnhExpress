﻿using DevExpress.Xpo;
using System;

namespace H3CExpress.UserControls
{
    public class PersistentClass1 : XPObject
    {
        public PersistentClass1() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public PersistentClass1(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }
    }

}