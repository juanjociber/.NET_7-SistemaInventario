﻿using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Data;
using SistemaInventario.Modelos;


namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class OrdenDetalleRepositorio : Repositorio<OrdenDetalle>, IOrdenDetalleRepositorio
    {
        private readonly ApplicationDbContext _db;

        public OrdenDetalleRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Actualizar(OrdenDetalle ordenDetalle)
        {
            _db.Update(ordenDetalle);
        }
    }
}
