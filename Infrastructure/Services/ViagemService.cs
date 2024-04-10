using Domain.Core;
using Domain.Interfaces;
using Domain.ViewModels;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ViagemService : IViagemService
    {
        private readonly IViagemRepository _repository;

        public ViagemService(IViagemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ViagemResponse>> GetViagens()
        {
            var viagem = await _repository.GetViagens();
            List<ViagemResponse> viagensResponde = null;
            if (viagem != null)
            {
                viagensResponde = new List<ViagemResponse>();
                foreach (var item in viagem)
                {
                    var v = new ViagemResponse()
                    {
                        ViagemId = item.ViagemId,
                        MotoristaId = item.MotoristaId,
                        DataHoraViagem = item.DataHoraViagem,
                        Entrega = item.Entrega,
                        Saida = item.Saida,
                        KmPercurso = item.KmPercurso,
                        PesoCarga = item.PesoCarga
                    };
                    viagensResponde.Add(v);
                }
            }
            return await Task.FromResult(viagensResponde);
        }

        public async Task<ViagemResponse> GetById(int id)
        {
            var viagem = await _repository.GetById(id);
            ViagemResponse getId = null;
            try
            {
                if (viagem != null)
                {
                    getId = new ViagemResponse()
                    {
                        ViagemId = viagem.ViagemId,
                        MotoristaId = viagem.MotoristaId,
                        Saida = viagem.Saida,
                        Entrega = viagem.Entrega,
                        DataHoraViagem = viagem.DataHoraViagem,
                        KmPercurso = viagem.KmPercurso
                    };
                }
                return await Task.FromResult(getId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ViagemResponse> CreateViagem(CreateViagemViewModel model)
        {
            try
            {
                var entity = new Viagem()
                {
                    ViagemId = model.IdViagem,
                    MotoristaId = model.MotoristaId,
                    PesoCarga = model.PesoCarga,
                    Saida = model.Saida,
                    Entrega = model.Entrega,
                    KmPercurso = model.KmPercurso,
                    DataHoraViagem = model.DataHoraViagem
                };

                var viagemCreate = await _repository.Create(entity);

                ViagemResponse response = new ViagemResponse()
                {
                    ViagemId = viagemCreate.ViagemId,
                    MotoristaId = viagemCreate.MotoristaId,
                    PesoCarga = viagemCreate.PesoCarga,
                    Saida = viagemCreate.Saida,
                    Entrega = viagemCreate.Entrega,
                    KmPercurso = viagemCreate.KmPercurso,
                    DataHoraViagem = viagemCreate.DataHoraViagem
                };

                return await Task.FromResult(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //API paga do Google.

        //private ViagemDados CalcularDistanciaEDuracao(string origem, string destino, out double distancia, out double duracao)
        //{
        //    distancia = duracao = 0;
        //    ViagemDados data = null;

        //    try
        //    {
        //        string url = string.Format("http://maps.googleapis.com/maps/api/directions/xml?origin={0}&destination={1}&mode=driving&language=pt-BR&sensor=false",
        //           origem, destino);
        //        System.Net.WebRequest request = System.Net.HttpWebRequest.Create(url);
        //        System.Net.WebResponse response = request.GetResponse();
        //        using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
        //        {
        //            string responseString = reader.ReadToEnd();
        //            RootObject responseData = JsonSerializer.Deserialize<RootObject>(responseString);
        //            if (responseData != null)
        //            {
        //                double distanciaRetornada = responseData.routes.Sum(r => r.legs.Sum(l => l.distance.value));
        //                double duracaoRetornada = responseData.routes.Sum(r => r.legs.Sum(l => l.duration.value));
        //                if (distanciaRetornada != 0)
        //                {
        //                    data = new ViagemDados()
        //                    {
        //                        Distancia = distanciaRetornada,
        //                        Duracao = duracaoRetornada
        //                    };
        //                }
        //            }
        //        }
        //    }
        //    catch { }

        //    return data;
        //}
    }
}