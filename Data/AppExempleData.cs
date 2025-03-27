using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProcessManagement.Models;

namespace CompanyProcessManagement.Data
{
    public class ExampleData
    {
        public static async Task AddExampleData(ApplicationDbContext context)
        {
            // Adiciona a Área de Pessoas
            var areaPessoas = new Area
            {
                Nome = "Pessoas",
                Departamento = "RH",
                Setor = "Recrutamento"
            };
            context.Areas.Add(areaPessoas);
            context.SaveChanges();

            // Processo: Recrutamento e Seleção
            var processoRecrutamento = new Process
            {
                Nome = "Recrutamento e Seleção",
                Descricao = "Processo para recrutamento e seleção de candidatos.",
                AreaId = areaPessoas.Id
            };
            context.Processos.Add(processoRecrutamento);  // Nome da DbSet ajustado
            await context.SaveChangesAsync();

            // Subprocessos de Recrutamento
            var subProcess1 = new SubProcess { Nome = "Definição de perfil da vaga", ProcessId = processoRecrutamento.Id };
            var subProcess2 = new SubProcess { Nome = "Divulgação da vaga", ProcessId = processoRecrutamento.Id };
            context.Subprocessos.AddRange(subProcess1, subProcess2);  // Nome da DbSet ajustado
            await context.SaveChangesAsync();

            // Ferramentas
            var ferramentaTrello = new Ferramenta { Nome = "Trello", Descricao = "Gestão de candidatos", ProcessoId = processoRecrutamento.Id };
            var ferramentaNotion = new Ferramenta { Nome = "Notion", Descricao = "Armazenamento de descrições das vagas", ProcessoId = processoRecrutamento.Id };
            context.Ferramentas.AddRange(ferramentaTrello, ferramentaNotion);
            await context.SaveChangesAsync();

            // Responsáveis
            var responsavelEquipe = new Responsavel { Nome = "Equipe de Recrutamento", ProcessoId = processoRecrutamento.Id };
            context.Responsaveis.Add(responsavelEquipe);
            await context.SaveChangesAsync();

            // Documentos
            var docFluxoRecrutamento = new Documento { Nome = "Fluxo de Recrutamento", Tipo = "PDF", ProcessoId = processoRecrutamento.Id };
            context.Documentos.Add(docFluxoRecrutamento);
            await context.SaveChangesAsync();
        }
    }
}