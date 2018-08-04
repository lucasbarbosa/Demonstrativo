using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gtf.Entity;
using Rhino.Mocks;
using Gtf.Interfaces;
using Gtf.Implementations;
using System;

namespace Gft.Test
{
    [TestClass]
    public class MealTest
    {
        #region Attributes
        IMyContext _db = MockRepository.GenerateStub<IMyContext>();
        IMealFactory _mealFactory;
        #endregion

        #region Constructor
        public MealTest()
        {
            _mealFactory = new MealFactory();
        }
        #endregion

        #region Teste para pedidos da manhã
        [TestMethod]
        public void PedidoManha_TresProdutos_Ok()
        {
            FakeMorningRequests();
            var morningMeal = _mealFactory.CreateMeal(_db, "manhã");
            var result = morningMeal.MakeResponse(_db, new[] { "manhã", "1", "2", "3" });
            Assert.AreEqual("ovos, torrada, café", result);
        }

        [TestMethod]
        public void PedidoManha_TresProdutosDesordenados_Ok()
        {
            FakeMorningRequests();
            var morningMeal = _mealFactory.CreateMeal(_db, "manhã");
            var result = morningMeal.MakeResponse(_db, new[] { "manhã", "2", "1", "3" });
            Assert.AreEqual("ovos, torrada, café", result);
        }

        [TestMethod]
        public void PedidoManha_TodosProdutos_Ok()
        {
            FakeMorningRequests();
            var morningMeal = _mealFactory.CreateMeal(_db, "manhã");
            var result = morningMeal.MakeResponse(_db, new[] { "manhã", "1", "2", "3", "4" });
            Assert.AreEqual("ovos, torrada, café, erro", result);
        }

        [TestMethod]
        public void PedidoManha_ProdutosRepetidos_Ok()
        {
            FakeMorningRequests();
            var morningMeal = _mealFactory.CreateMeal(_db, "manhã");
            var result = morningMeal.MakeResponse(_db, new[] { "manhã", "1", "2", "3", "3", "3" });
            Assert.AreEqual("ovos, torrada, café (x3)", result);
        } 
        #endregion

        #region Testes para pedidos da noite
        [TestMethod]
        public void PedidoNoite_TodosProdutos_Ok()
        {
            FakeNightRequests();
            var nightMeal = _mealFactory.CreateMeal(_db, "noite");
            var result = nightMeal.MakeResponse(_db, new[] { "noite", "1", "2", "3", "4", });
            Assert.AreEqual("carne, batata, vinho, bolo", result);
        }

        [TestMethod]
        public void PedidoNoite_ProdutosRepetidos_Ok()
        {
            FakeNightRequests();
            var nightMeal = _mealFactory.CreateMeal(_db, "noite");
            var result = nightMeal.MakeResponse(_db, new[] { "noite", "1", "2", "2", "4", });
            Assert.AreEqual("carne, batata (x2), bolo", result);
        } 
        #endregion
        
        #region Testes que disparam exception

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PedidoNoite_CincoProdutos_Erro()
        {
            FakeNightRequests();
            var nightMeal = _mealFactory.CreateMeal(_db, "noite");
            var result = nightMeal.MakeResponse(_db, new[] { "noite", "1", "2", "3", "4", "5", });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PedidoErrado_Tarde_Erro()
        {
            FakeNightRequests();
            var nightMeal = _mealFactory.CreateMeal(_db, "tarde");
            var result = nightMeal.MakeResponse(_db, new[] { "tarde", "1", "2", "3" });
        }
        #endregion

        #region Fake
        private void FakeMorningRequests()
        {
            _db.Stub(x => x.GetFirstPeriod("manhã")).Return(new Period { Description = "manhã", Id = 1 });
            _db.Stub(x => x.GetMealDescription(1, 1)).Return("ovos");
            _db.Stub(x => x.GetMealDescription(2, 1)).Return("torrada");
            _db.Stub(x => x.GetMealDescription(3, 1)).Return("café");
            _db.Stub(x => x.GetMealDescription(4, 1)).Return("erro");
        }

        private void FakeNightRequests()
        {
            _db.Stub(x => x.GetFirstPeriod("noite")).Return(new Period { Description = "noite", Id = 2 });
            _db.Stub(x => x.GetMealDescription(1, 2)).Return("carne");
            _db.Stub(x => x.GetMealDescription(2, 2)).Return("batata");
            _db.Stub(x => x.GetMealDescription(3, 2)).Return("vinho");
            _db.Stub(x => x.GetMealDescription(4, 2)).Return("bolo");
        } 
        #endregion
    }
}
