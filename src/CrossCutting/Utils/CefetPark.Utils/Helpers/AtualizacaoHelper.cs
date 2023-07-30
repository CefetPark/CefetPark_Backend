using System.Collections;
using System.Reflection;

namespace CefetPark.Utils.Helpers
{
    public class AtualizacaoHelper
    {
        public static void AtualizarCamposEntidadeComBaseNaViewModel<T, Y>(T viewModel, Y entidade)
        {
            List<string> camposDaEntidade = entidade.GetType().GetProperties().Select(x => x.Name).ToList();
            foreach (var prop in viewModel.GetType().GetProperties())
            {
                if (camposDaEntidade.Contains(prop.Name) && prop.Name != "Id")
                {
                    if (typeof(ICollection).IsAssignableFrom(viewModel.GetType().GetProperty(prop.Name).GetValue(viewModel).GetType()))
                    {

                    }
                    else if (viewModel.GetType().GetProperty(prop.Name).PropertyType == typeof(string) || viewModel.GetType().GetProperty(prop.Name).PropertyType.IsClass == false)
                    {
                        var valorCampo = viewModel.GetType().GetProperty(prop.Name).GetValue(viewModel);
                        entidade.GetType().GetProperty(prop.Name).SetValue(entidade, valorCampo);
                    }
                    else
                    {
                        List<string> camposDaEntidadeDoAtributo = entidade.GetType().GetProperty(prop.Name).GetValue(entidade).GetType().GetProperties().Select(x => x.Name).ToList();

                        foreach (var propAtributo in viewModel.GetType().GetProperty(prop.Name).GetValue(viewModel).GetType().GetProperties())
                        {
                            if (camposDaEntidadeDoAtributo.Contains(propAtributo.Name) && propAtributo.Name != "Id")
                            {
                                var valorCampo = viewModel.GetType().GetProperty(prop.Name)?.GetValue(viewModel);
                                var valorDoCampo = valorCampo?.GetType().GetProperty(propAtributo.Name)?.GetValue(valorCampo);

                                var propriedadeAtributoEntidade = entidade.GetType().GetProperty(prop.Name).GetValue(entidade).GetType().GetProperty(propAtributo.Name);

                                propriedadeAtributoEntidade.SetValue(entidade.GetType().GetProperty(prop.Name).GetValue(entidade), valorDoCampo);
                            }

                        }

                    }

                }
            }
        }

    }
}
