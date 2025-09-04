using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOs;
using MinimalApi.Dominio.Servicos;

namespace MinimalApi.Dominio.Interfaces;

public interface IAdministradorServico
{
    Administrador? Login(LoginDTO loginDTO);
    Administrador Incluir(Administrador administrador);
    Administrador? BuscaPorId(int id);
    List<Administrador> Todos(int? pagina);
}