﻿namespace Holtz_PDV.Models.Enums
{
    public static class Tipo
    {
        public const string CODIGO = "INT";

        public const string DATETIME = "DATETIME";
        public const string DATE = "DATE";

        public const string VARCHAR030 = "VARCHAR(30)";
        public const string VARCHAR050 = "VARCHAR(50)";
        public const string VARCHAR075 = "VARCHAR(75)";
        public const string VARCHAR100 = "VARCHAR(100)";
        public const string VARCHAR130 = "VARCHAR(130)";
        public const string VARCHAR150 = "VARCHAR(150)";
        public const string VARCHAR300 = "VARCHAR(300)";
        public const string VARCHAR500 = "VARCHAR(500)";
        public const string VARCHAR1000 = "VARCHAR(1000)";
        public const string VARCHAR10000 = "VARCHAR(10000)";


        public const string STATUS_ATIVO_INATIVO = "TINYINT"; //0 - 255
        public const string STATUS_DUPLICATA = "TINYINT"; //0 - 255
        public const string STATUS_PEDIDO = "TINYINT"; //0 - 255

        public const string TIPO_USUARIO = "TINYINT"; //0 - 255
        public const string TIPO_PESSOA = "TINYINT"; //0-255

        public const string UF = "VARCHAR(2)";
        public const string CPF_CNPJ = "VARCHAR(18)";
        public const string MOEDA = "DECIMAL(17,2)";
    }
}
