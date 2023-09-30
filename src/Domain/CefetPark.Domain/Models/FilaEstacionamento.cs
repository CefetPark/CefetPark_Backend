namespace CefetPark.Domain.Models
{
    public class FilaEstacionamento : CommonModelCaching
    {
        public int Estacionamento_Id { get; set; }
        public ICollection<IntegranteFilaEstacionamento> Integrantes { get; private set; }

        public IntegranteFilaEstacionamento? ChamadoParaEstacionar { get; set; }

        public FilaEstacionamento(int estacionamentoId) : base(estacionamentoId)
        {
            Estacionamento_Id = estacionamentoId;
            Integrantes = new List<IntegranteFilaEstacionamento>();
        }


        public bool ExisteIntegrantesNaFila()
        {
            return Integrantes.Any();
        }

        public bool PreencherPosicoesIntegrantes()
        {
            var i = 1;
            foreach (var integrante in Integrantes)
            {
                integrante.Posicao = i++;
                
            }
            return true;
        }
        
        public bool EntrarFila(IntegranteFilaEstacionamento integrante)
        {
            integrante.Posicao = Integrantes.Count() + 1;
            Integrantes.Add(integrante);
            return true;
        }

        public bool DesistirFila(int usuarioId)
        {
            var integranteDesistente = Integrantes.FirstOrDefault(x => x.Usuario_Id == usuarioId);

            if(integranteDesistente != null)
            {
                Integrantes.Remove(integranteDesistente);
            }
            else if(ChamadoParaEstacionar != null && ChamadoParaEstacionar.Usuario_Id == usuarioId)
            {
                LimparChamadoParaEstacionar();
            }
            else
            {
                throw new Exception("usuarioId não encontrado na fila");
            }
           
            return true;
        }

        public bool ChamarProximoDaFila()
        {
            var primeiroDaFila = Integrantes.ElementAt(0);

            if (primeiroDaFila == null) throw new Exception($"A Fila para o estacionamento {Estacionamento_Id} encontra-se vazia");

            ChamadoParaEstacionar = primeiroDaFila;

            Integrantes.Remove(primeiroDaFila);

            return true;
        }

        public bool LimparChamadoParaEstacionar()
        {
            ChamadoParaEstacionar = null;
            return true;
        }
    }
}
