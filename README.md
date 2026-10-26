# Central de Chamados (Helpdesk)

> Trabalho Prático da disciplina de Programação Orientada por Objetos  
> Curso de Análise e Desenvolvimento de Sistemas – PUC Minas (Campus Betim)  
> Professor: Jardell Fillipe da Silva  

---

## 📖 Descrição do Sistema
O **Sistema de Central de Chamados (Helpdesk)** é uma solução desenvolvida sob os pilares da Programação Orientada a Objetos (POO) para gerenciar o ciclo de vida de tickets de suporte técnico dentro de uma organização. A aplicação é responsável por receber solicitações dos usuários, distribuí-las entre a equipe técnica conforme a capacidade de atendimento e monitorar ativamente os prazos de resolução acordados (SLA).

---

## 👥 Integrantes do Grupo
* Gustavo Venâncio Fonseca - Matrícula: 893058
* Gabriel Lucas Souza de Oliveira - Matrícula: 892896
* Arthur Moreira Silva - Matrícula: 892226
* Thulio Funayama - Matrícula: 891452
* Lucas Henrique Souza - Matrícula: 865704

---

## ⚙️ Funcionalidades Principais
- **Abertura de Chamados:** Cadastro de novos tickets com classificação adequada por categoria e tipo.
- **Distribuição e Atribuição:** Vinculação de tickets a técnicos responsáveis, respeitando limites operacionais.
- **Gestão de Ciclo de Vida:** Controle e atualização de estados do chamado (*Aberto*, *Em Atendimento*, *Resolvido*, *Fechado*).
- **Rastreabilidade e Histórico:** Registro cronológico de todas as alterações de situação e interações técnicas.
- **Monitoramento de SLA:** Identificação e listagem automatizada de chamados vencidos ou próximos do prazo-limite.

---

## 📌 Regras de Negócio Fundamentais
1. **Prazos Customizados por Tipo:** Cada tipo específico de chamado possui cálculo de prazo e prioridade próprios.
2. **Imutabilidade de Chamados Fechados:** Uma vez com a situação definida como *Fechado*, o chamado não pode mais ser editado.
3. **Capacidade Operacional do Técnico:** Cada técnico possui um limite máximo de chamados simultâneos no estado *Em Atendimento*.
4. **Log de Auditoria Obrigatório:** Qualquer transição de situação do ticket gera compulsoriamente uma entrada no histórico do atendimento.

---

## 🏗️ Modelagem Inicial de Classes
A arquitetura do sistema explora os princípios de abstração, encapsulamento, herança e polimorfismo através das seguintes entidades centrais:

- **`Chamado` (Classe Abstrata):** Classe-mãe que encapsula dados comuns (código, título, solicitante, status) e define métodos polimórficos como `CalcularPrazo()` e `Prioridade()`.
  - **`Incidente` (Subclasse):** Representa falhas que interrompem serviços; implementa cálculo de prazo curto e alta prioridade.
  - **`Requisicao` (Subclasse):** Demandas por novos serviços ou acessos com prazos intermediários de entrega.
  - **`Duvida` (Subclasse):** Esclarecimentos e consultas operacionais com prazos flexíveis.
- **`Tecnico` e `Solicitante`:** Entidades que representam os atores do sistema e suas respectivas atribuições.
- **`Categoria`:** Classificação temática do chamado para triagem.
- **`RegistroDeAtendimento`:** Entidade de histórico encarregada de registrar as mudanças de estado, datas e observações.

---

## 📂 Status do Projeto
- [x] **Entrega Parcial:** Modelagem conceitual, classes e aplicação dos 4 pilares de POO
- [ ] Implementação da lógica de domínio e regras de negócio
- [ ] Persistência de dados e estrutura de controle
- [ ] Entrega Final
