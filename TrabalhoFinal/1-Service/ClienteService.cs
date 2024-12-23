﻿using FrontEnd.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._2_Repository;
using TrabalhoFinal._2_Repository.Interface;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._1_Service
{
    public class ClienteService : IClienteService
    {
        public readonly IClienteRepository repository;

        public ClienteService(IClienteRepository _repository)
        {
            repository = _repository;
        }

        public void Adicionar(Cliente c)
        {
            repository.Adicionar(c);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Cliente> Listar()
        {
            return repository.Listar();
        }

        public void Editar(Cliente c)
        {
            repository.Editar(c);
        }

        public Cliente BuscarPorId(int id)
        {
            return repository.BuscarPorId(id);
        }

        public Cliente FazerLogin(ClienteLoginDTO usuarioLogin)
        {
            List<Cliente> listcliente = Listar();
            foreach (Cliente cliente in listcliente)
            {
                if (cliente.UsuarioName == usuarioLogin.UsuarioName
                    && cliente.Senha == usuarioLogin.Senha)
                {
                    return cliente;
                }
            }
            return null;
        }


    }
}
