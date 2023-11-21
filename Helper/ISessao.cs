using SistemaOrcamentario.Models;

namespace SistemaOrcamentario.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaoDoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();
        int? ObterIdUsuarioLogado();
    }
}
