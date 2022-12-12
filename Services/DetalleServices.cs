using Model.Custom;
using Model.Domain;
using Persistanse;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Services
{
    public class DetalleServices
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        private readonly FacturaServices facturaServices = new FacturaServices();
        private readonly ProyectoServices proyectoServices = new ProyectoServices();

        public IEnumerable<DetalleGrid> GetAll()
        {
            var result = new List<DetalleGrid>();

            using (var db = new ApplicationDbContext())
            {
                result = (
                        from det in db.Detalles.Where(x=>x.Emitida == false)
                        select new DetalleGrid
                        {
                            id = det.Id_Detalle,
                            PrecioU = det.PrecioUnitario,
                            SubTotal = det.SubTotal,
                            Cantidad = det.Cantidad,
                            Id_Proyecto = det.Id_Proyecto,
                            Titulo = det.Proyectos.Titulo,
                            Descripcion = det.Descripcion
                        }
                    ).ToList();

            }

            return result;
        }

        
        public DetalleGrid Get(int id)
        {
            var result = new DetalleGrid();

            using (ctx)
            {
                result = ( from det in ctx.Detalles.Where(x=> x.Id_Detalle == id)
                           select new DetalleGrid
                           {
                               id = det.Id_Detalle,
                               PrecioU = det.PrecioUnitario,
                               Cantidad = det.Cantidad,
                               SubTotal = det.SubTotal,
                               Id_Proyecto = det.Id_Proyecto,
                               Titulo = det.Proyectos.Titulo,
                               Descripcion = det.Descripcion
                               
                           }).Single();
            }

            return result;
        }

        public void Create(Detalle detalle)
        {
            using (ctx)
            {
                var Detalle = new Detalle
                {
                    Id_Detalle = detalle.Id_Detalle,
                    Id_Factura = detalle.Id_Factura,
                    Id_Proyecto = detalle.Id_Proyecto,
                    Cantidad = detalle.Cantidad,
                    PrecioUnitario = detalle.PrecioUnitario,
                    SubTotal = detalle.Cantidad * detalle.PrecioUnitario,
                    Descripcion = detalle.Descripcion
                };

                ctx.Detalles.Add(Detalle);  
                ctx.SaveChanges();

                Factura factura = ctx.Facturas.Where(x => x.Id_Factura == detalle.Id_Factura).Single();
                facturaServices.Update(factura);
                Proyectos proyecto = ctx.Proyectos.Where(x => x.Id_Proyecto == detalle.Id_Proyecto).Single();
                proyectoServices.Update(proyecto);
            }
        }
        public void CreateEmitida(Detalle detalle)
        {
            using (ctx)
            {
                var Detalle = new DetalleEmitido
                {
                    Id_Detalle = detalle.Id_Detalle,
                    PrecioUnitario = detalle.PrecioUnitario,
                    Cantidad = detalle.Cantidad,
                    Descripcion = detalle.Descripcion,
                    SubTotal = detalle.Cantidad * detalle.PrecioUnitario,
                    Id_Proyecto = detalle.Id_Proyecto,
                    Titulo = detalle.Proyectos.Titulo,
                    Id_Factura = detalle.Id_Factura,
                };

                ctx.DetallesEmitidos.Add(Detalle);  
                //ctx.SaveChanges();
            }
        }
        public Detalle GetEdit(int id)
        {
            var result = new Detalle();

            using (var db = new ApplicationDbContext())
            {
                result = db.Detalles.Where(x => x.Id_Detalle == id).Single();
            }
            return result;
        }

        public void Update(Detalle Detalle)
        {
            using (ctx)
            {
                var originalEntity = ctx.Detalles.Where(x => x.Id_Detalle
                == Detalle.Id_Detalle
                ).Single();

                originalEntity.Id_Detalle = Detalle.Id_Detalle;
                originalEntity.Id_Proyecto = Detalle.Id_Proyecto;
                originalEntity.Id_Factura = Detalle.Id_Factura;
                originalEntity.Cantidad = Detalle.Cantidad;
                originalEntity.PrecioUnitario = Detalle.PrecioUnitario;
                originalEntity.SubTotal = Detalle.PrecioUnitario * Detalle.Cantidad;
                originalEntity.Descripcion = Detalle.Descripcion;
                originalEntity.Emitida = Detalle.Emitida;
                
                ctx.Entry(originalEntity).State = EntityState.Modified;
                ctx.SaveChanges();
                Factura factura = ctx.Facturas.Where(x => x.Id_Factura == Detalle.Id_Factura).Single();
                facturaServices.Update(factura);
                Proyectos proyecto = ctx.Proyectos.Where(x => x.Id_Proyecto == Detalle.Id_Proyecto).Single();

                proyectoServices.Update(proyecto);
            }
        }
        
        public void Emitir(Detalle Detalle)
        {
            using (ctx)
            {
                var originalEntity = ctx.Detalles.Where(x => x.Id_Detalle
                == Detalle.Id_Detalle
                ).Single();

                originalEntity.Id_Detalle = Detalle.Id_Detalle;
                originalEntity.Id_Proyecto = Detalle.Id_Proyecto;
                originalEntity.Id_Factura = Detalle.Id_Factura;
                originalEntity.Cantidad = Detalle.Cantidad;
                originalEntity.PrecioUnitario = Detalle.PrecioUnitario;
                originalEntity.SubTotal = Detalle.PrecioUnitario * Detalle.Cantidad;
                originalEntity.Descripcion = Detalle.Descripcion;
                originalEntity.Emitida = true;
                
                ctx.Entry(originalEntity).State = EntityState.Modified;
                ctx.SaveChanges();

                CreateEmitida(Detalle);
            }
        }

        public IEnumerable<Detalle> DetallesDeFactura(int id)
        {
            var result = new List<Detalle>();
            using (var db = new ApplicationDbContext())
            {
                result = db.Detalles.Where(x => x.Id_Factura == id).ToList();
            }

            return result;
        }

        public IEnumerable<DetalleEmitido> DetallesDeFacturaEmitida(int id)
        {
            var result = new List<DetalleEmitido>();
            using (var db = new ApplicationDbContext())
            {
                result = db.DetallesEmitidos.Where(x => x.Id_Factura == id).ToList();
            }

            return result;
        }

        public void Delete(int id)
        {
            try
            {
                using (ctx)
                {
                    Detalle Detalle = ctx.Detalles.Where(x => x.Id_Detalle == id).Single();

                    ctx.Detalles.Remove(Detalle);
                    
                    ctx.SaveChanges();
                    Factura factura = ctx.Facturas.Where(x => x.Id_Factura == Detalle.Id_Factura).Single();
                    facturaServices.Update(factura);
                    Proyectos proyecto = ctx.Proyectos.Where(x => x.Id_Proyecto == Detalle.Id_Proyecto).Single();
                    proyectoServices.Update(proyecto);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}