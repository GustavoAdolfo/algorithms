using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace Aplicacao.Models
{
    public class MisterioModel
    {
        public int IdSuspeito { get; set; }
        public int IdArma { get; set; }
        public int IdLocal { get; set; }
        public string IdMisterio { get; set; } = Guid.NewGuid().ToString();

        public MisterioModel()
        {
                //Id = Guid.NewGuid();
        }

        public bool IsValid()
        {
            return IdSuspeito > 0 
                && IdArma > 0 
                && IdLocal > 0 
                && !string.IsNullOrWhiteSpace(IdMisterio);

        }
    }
}