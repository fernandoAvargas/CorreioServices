namespace CorreioServices
{
    using GeneralServices;
    using System;
    using System.IO;
    using System.ServiceModel;

    class Program
    {
        static void Main(string[] args)
        {

            ConsultaCEP("22290240");
        }

        private static void ConsultaCEP(string cep)
        {
            using (var ws = new AtendeClienteClient())
            {

                try
                {
                    var resposta = ws.consultaCEP(cep);

                    string endereco = resposta.end == null ? "Não informado" : resposta.end;
                    string bairro = resposta.bairro == null ? "Não informado" : resposta.bairro;
                    string cidade = resposta.cidade == null ? "Não informado" : resposta.cidade;
                    string uf = resposta.uf == null ? "Não informado" : resposta.uf;
                    string complemento = resposta.complemento2 == null ? "Não Informado" : resposta.complemento2;

                    Console.Clear();
                    Console.WriteLine(String.Format("Endereço : {0}", endereco));
                    Console.WriteLine(String.Format("Bairro : {0}", bairro));
                    Console.WriteLine(String.Format("Cidade : {0}", cidade));
                    Console.WriteLine(String.Format("Uf : {0}", uf));
                    Console.WriteLine(String.Format("Complemento : {0}", complemento));
                    Console.WriteLine(String.Format("CEP : {0}", resposta.cep));
                    Console.WriteLine("");
                    Console.ReadKey();
                }
                catch (FaultException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
              
            }


        }
    }
}
