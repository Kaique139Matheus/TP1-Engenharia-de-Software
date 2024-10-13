# TP1-Engenharia-de-Software

## Easy Booking - Sistema de Reservas para Pequenos Estabelecimentos
EasyBooking é um sistema de reservas inovador, projetado para facilitar a conexão entre estabelecimentos e clientes de forma rápida e eficiente. Os estabelecimentos podem cadastrar seus horários de funcionamento, serviços oferecidos e detalhes sobre cada opção, permitindo que os clientes explorem uma ampla gama de possibilidades antes de realizar suas reservas. 
Com a opção de filtros, os usuários podem buscar por localização, tipo de serviço, disponibilidade e até avaliações, garantindo uma escolha mais personalizada e alinhada às suas necessidades. Além de facilitar a marcação de horários, o EasyBooking permite que clientes e estabelecimentos gerenciem suas reservas de maneira prática e intuitiva, com a possibilidade de cancelar ou reagendar compromissos com apenas alguns cliques. 
O sistema de avaliação também desempenha um papel fundamental, onde os clientes podem compartilhar suas experiências e avaliar os serviços prestados, ajudando outros usuários a fazerem escolhas mais informadas e incentivando os estabelecimentos a aprimorarem continuamente a qualidade do atendimento.

### Tecnologias
- **Front-end:** JavaScript + React + Node.js
- **Back-end:** C# + SQL

### Integrantes e Papeis
- **Filipe de Araújo Mendes:** Back-end.
- **João Pedro Carvalho de Paula Resende:** Front-end.
- **Kaique Matheus Sousa:** Integração.
- **Leandro dos Santos Lopo Silva:** Full Stack.

- ---

# Backlog do Produto

1. **Como prestador de serviço**, eu gostaria de adicionar e remover serviços.
2. **Como cliente**, eu gostaria de verificar a disponibilidade de horários e fazer uma reserva.
3. **Como cliente**, eu gostaria de adicionar uma avaliação (comentário e nota) sobre minha experiência no estabelecimento.
4. **Como usuário**, eu gostaria de fazer login e logout no sistema.
5. **Como cliente**, eu gostaria de cancelar ou mudar a data da minha reserva.
6. **Como cliente**, eu gostaria de visualizar e editar as informações do meu perfil.
7. **Como prestador de serviço**, eu gostaria de conseguir um relatório de reservas.
8. **Como prestador de serviço**, eu gostaria de gerenciar os preços das reservas.
9. **Como prestador de serviço**, eu gostaria de visualizar relatórios financeiros.
10. **Como cliente**, eu gostaria de poder compartilhar os dados de minha reserva com outras pessoas.
11. **Como prestador de serviço**, eu gostaria de poder responder às avaliações.
12. **Como cliente**, eu gostaria de ver uma agenda com minhas reservas.
13. **Como prestador de serviço**, eu gostaria de poder precificar as reservas.
14. **Como cliente**, eu gostaria de filtrar os estabelecimentos por localização, avaliação, disponibilidade ou preço.

---

# Backlog do Sprint

## História 1: 
**Como prestador de serviço**, eu gostaria de adicionar e remover serviços.

### Tarefas e responsáveis:
- [ ] Configurar ambiente React e Node.js [João]
- [ ] Criar banco de dados e configurar tabelas para os serviços [Filipe]
- [ ] Instalar ambiente .NET [Leandro]
- [ ] Criar rota para criação e remoção de serviços [Leandro]
- [ ] Criar tela de cadastramento de serviços no front-end [João]
- [x] Integrar backend e frontend [Kaique]

## História 2: 
**Como cliente**, eu gostaria de verificar a disponibilidade de horários e fazer uma reserva.

### Tarefas e responsáveis:
- [ ] Desenvolver a rota de criação de reserva [Leandro]
- [ ] Implementar lógica no backend para verificar horários disponíveis [Leandro]
- [ ] Criar interface de seleção de datas e horários disponíveis [João e Kaique]
- [ ] Integrar lógica de reserva no frontend [Kaique]

## História 3: 
**Como cliente**, eu gostaria de adicionar uma avaliação (comentário e nota) sobre minha experiência no estabelecimento.

### Tarefas e responsáveis:
- [ ] Criar tabelas de comentários e adicionar ao banco de dados [Filipe]
- [ ] Criar rotas no backend para adicionar, editar e remover comentários [Filipe]
- [ ] Implementar modal de avaliação [João]
- [ ] Integrar lógica de avaliações ao frontend [Kaique]

## História 4: 
**Como usuário**, eu gostaria de fazer login e logout no sistema.

### Tarefas e responsáveis:
- [ ] Criar tabelas de contas de usuários e adicionar ao banco de dados [Filipe]
- [ ] Implementar lógica de login e logout [Filipe]
- [ ] Criar tela de login [João e Kaique]
- [ ] Criar botão para logout do sistema [João]
- [ ] Integrar frontend com backend login e logout [Kaique]

