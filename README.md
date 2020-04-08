# desafio-backend
Projeto teste backend 


### Acesso aos serviços
Foi utilizado o pacote Flurl para conexão com os serviços que fornecem dos dados dos investimentos.
Utilizo esse recurso com frequencia pois entende que facilita o consumo de APIs REST e também a leitura do código.
Optei por definir os endpoints no arquivo de configuração.

Para atender aos princípios SOLID e imaginando que em algum momento a quantidade de serviços pode aumentar, criei um serviço de aplicação que fará o acesso aos endpoints de Renda Fixa, Tesouro Direto e Fundos. Esse serviço consumo um Builder que fornece a lista de ACLs consultadas.

Normalmente coloco as APIs REST consumidas dentro de uma biblioteca ACL isolando assim somente os dados necessários no "domínio delimitado" do microsserviço.

### Cálculos
Os cálculos de IR foram feitos diretamente nas entidades de cada ACL, mas entendo que cabe uma melhoria para parametrização do valor.
Para o cálculo do valor de retirada utilizei um método do objeto que nomeei como InvestimentoConsolidado, que tem a responsabilidade de fazer o cálculo para cada Investimento filho.
Talvez essa organização possa ser repensada avaliando se pensarmos que o Consolidado não é uma raiz de agregação que contém investimentos.
O mapeamento correto desse relacionamento envolve um conhecimento maior do domínio.

### Cache
Para armazenamento do cache utilizei o serviço do Azure e o pacote Microsoft.Extensions.Caching.Redis (preferência pessoal).



