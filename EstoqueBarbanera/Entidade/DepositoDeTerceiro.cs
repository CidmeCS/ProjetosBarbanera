﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidade
{
    public class DepositoDeTerceiro
    {
        [Key]
        public int Id { get; set; }
        public string Deposito { get; set; }
        public string Nome { get; set; }
    }
}
