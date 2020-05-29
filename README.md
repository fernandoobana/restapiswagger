# restapiswagger
Testando o uso do swagger para documentar e, ao mesmo tempo, facilitar os testes de uma API.

Api criada utilizando .Net Core 3.1.

A API em si não faz nada, apenas contém métodos para que sejam visíveis ao Swagger.

O método GetById foi marcado com o atributo [ApiExplorerSettings(IgnoreApi = true)] para que ele não apareça na UI (cenário em que você não quer expor tal método)
