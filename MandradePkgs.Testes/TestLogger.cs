using System;
using System.Linq;
using MandradePkgs.Mensagens;
using Xunit.Abstractions;

namespace MandradePkgs.Testes
{
    public class TestLogger
    {
        private IMensagensApi _mensagens;
        private ITestOutputHelper _output;

        public TestLogger(IMensagensApi mensagens, ITestOutputHelper output)
        {
            _mensagens = mensagens;
            _output = output;
        }

        public TestLogger(ITestOutputHelper output)
        {
            _output = output;
        }

        public void GravarLogs(string teste, object dados){
            _output.WriteLine($"\nTeste: {teste}");
            _output.WriteLine(GerarLogObjeto(dados));
            _output.WriteLine(GerarLogMensagens());
        }

        private string GerarLogObjeto(object dados){
            if (dados == null)
                throw new ArgumentException("Objeto de dados não informado");

            var props = dados.GetType().GetProperties().ToList();
            string dadosString = "Dados: ";

            foreach(var prop in props)
                dadosString += $"\n\t{prop.Name}: {prop.GetValue(dados, null)}";

            return dadosString;
        }

        private string GerarLogMensagens(){
            if (_mensagens == null)
                throw new ArgumentException("Objeto de mensagens não informado");

            var stringCompleta = "Mensagens: ";

            foreach(var msg in _mensagens.Mensagens)
                stringCompleta += $"\n\t{msg.Texto}";

            return stringCompleta;
        }
    }
}