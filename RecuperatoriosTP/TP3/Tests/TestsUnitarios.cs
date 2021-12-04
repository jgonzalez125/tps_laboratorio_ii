using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.Excepciones;
using Entidades.Archivos;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        /// <summary>
        /// Valida que las entradas esten instanciadas cuando se construye el
        /// festival
        /// </summary>
        [Test]
        public void TestEntradasInstanciadas()
        {
            Festival festival = new Festival();
            Festival festival2 = new Festival("Nombre Festival");

            Assert.IsInstanceOf(typeof(List<Entrada>), festival.Entradas);
            Assert.IsInstanceOf(typeof(List<Entrada>), festival2.Entradas);
        }

        /// <summary>
        /// Valida que se dispare la excepcion cuando las plateas tienen el mismo
        /// numero de butaca
        /// </summary>
        
        [Test]
        public void TestExcepcionPlatea()
        {
            Festival festival = new Festival();
            
            Entrada entrada = new Platea("M19", 230, true, "Nombre Festival");
            festival += entrada;
            Entrada entrada2 = new Platea("M19", 230, false, "Nombre Festival");

            Assert.Throws<FestivalException>(() => festival += entrada2);
        }

        /// <summary>
        /// Valida que la funcionalidad de guardar archivo funcione correctamente
        /// </summary>
       [Test]
        public void TestArchivoGuardado()
        {
            JsonManager<Entrada> jsonManager = new JsonManager<Entrada>();
            Entrada entrada = new Platea("M19", 230, true, "Nombre Festival");

            jsonManager.Guardar(entrada);
            Assert.IsTrue(jsonManager.Guardar(entrada));
        }
    }
}