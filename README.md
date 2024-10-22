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
- [ ] Integrar backend e frontend [Kaique]

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


# Getting Started with Create React App

This project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app).

## Available Scripts

In the project directory, you can run:

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in your browser.

The page will reload when you make changes.\
You may also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.\
See the section about [running tests](https://facebook.github.io/create-react-app/docs/running-tests) for more information.

### `npm run build`

Builds the app for production to the `build` folder.\
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.\
Your app is ready to be deployed!

See the section about [deployment](https://facebook.github.io/create-react-app/docs/deployment) for more information.

### `npm run eject`

**Note: this is a one-way operation. Once you `eject`, you can't go back!**

If you aren't satisfied with the build tool and configuration choices, you can `eject` at any time. This command will remove the single build dependency from your project.

Instead, it will copy all the configuration files and the transitive dependencies (webpack, Babel, ESLint, etc) right into your project so you have full control over them. All of the commands except `eject` will still work, but they will point to the copied scripts so you can tweak them. At this point you're on your own.

You don't have to ever use `eject`. The curated feature set is suitable for small and middle deployments, and you shouldn't feel obligated to use this feature. However we understand that this tool wouldn't be useful if you couldn't customize it when you are ready for it.

## Learn More

You can learn more in the [Create React App documentation](https://facebook.github.io/create-react-app/docs/getting-started).

To learn React, check out the [React documentation](https://reactjs.org/).

### Code Splitting

This section has moved here: [https://facebook.github.io/create-react-app/docs/code-splitting](https://facebook.github.io/create-react-app/docs/code-splitting)

### Analyzing the Bundle Size

This section has moved here: [https://facebook.github.io/create-react-app/docs/analyzing-the-bundle-size](https://facebook.github.io/create-react-app/docs/analyzing-the-bundle-size)

### Making a Progressive Web App

This section has moved here: [https://facebook.github.io/create-react-app/docs/making-a-progressive-web-app](https://facebook.github.io/create-react-app/docs/making-a-progressive-web-app)

### Advanced Configuration

This section has moved here: [https://facebook.github.io/create-react-app/docs/advanced-configuration](https://facebook.github.io/create-react-app/docs/advanced-configuration)

### Deployment

This section has moved here: [https://facebook.github.io/create-react-app/docs/deployment](https://facebook.github.io/create-react-app/docs/deployment)

### `npm run build` fails to minify

This section has moved here: [https://facebook.github.io/create-react-app/docs/troubleshooting#npm-run-build-fails-to-minify](https://facebook.github.io/create-react-app/docs/troubleshooting#npm-run-build-fails-to-minify)

