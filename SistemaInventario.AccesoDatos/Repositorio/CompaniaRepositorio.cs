﻿using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Data;
using SistemaInventario.Modelos;


namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class CompaniaRepositorio : Repositorio<Compania>, ICompaniaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CompaniaRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Actualizar(Compania compania)
        {
            var companiaBD = _db.Companias.FirstOrDefault(b => b.Id == compania.Id);
            if (companiaBD != null)
            {
                companiaBD.Nombre = compania.Nombre;
                companiaBD.Descripcion = compania.Descripcion;
                companiaBD.Pais = compania.Pais;
                companiaBD.Ciudad = compania.Ciudad;
                companiaBD.Direccion = compania.Direccion;
                companiaBD.Telefono = compania.Telefono;
                companiaBD.BodegaVentaId = compania.BodegaVentaId;
                companiaBD.ActualizadoPorId = compania.ActualizadoPorId;
                companiaBD.FechaActualizacion = compania.FechaActualizacion;
                _db.SaveChanges();
            }
        }
    }
}
