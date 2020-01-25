﻿using System.Collections.Generic;
using System.Linq;

namespace MandradePkgs.Mensagens.Estrutura.Implementacao
{
    internal class MensagensApi : IMensagensApi {
        public List<Mensagem> Mensagens { get; }

        public MensagensApi() {
            Mensagens = new List<Mensagem>();
        }

        public void AdicionarMensagem(string mensagem) => Mensagens.Add(new Mensagem(mensagem));
        public void AdicionarMensagem(TipoMensagem tipoMensagem, string mensagem) => Mensagens.Add(new Mensagem(tipoMensagem, mensagem));
        public bool PossuiMensagensErro() => Mensagens.Any(x => x.Tipo == (int)TipoMensagem.Erro);
        public bool PossuiFalhasValidacao() => Mensagens.Any(x => x.Tipo == (int)TipoMensagem.FalhaValidacao);
    }
}
