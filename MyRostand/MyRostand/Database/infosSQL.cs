﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyRostand.Database
{
    class infosSQL
    {
        public static List<string> getInfos()
        {
            List<string> infos = new List<string>();

            infos.Add("51.75.25.38");     //HOST  SERVEUR : 172.20.82.31
            infos.Add("3306");         //PORT
            infos.Add("myrostand");    //DATABASE NAME
            infos.Add("toto");         //USER NAME
            infos.Add("thomassio");             //USER PASSWORD

            return infos;
        }
    }
}