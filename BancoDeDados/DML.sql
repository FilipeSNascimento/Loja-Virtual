--CADASTRO DE USUÁRIO

begin;

-- Registro de endereço
insert into tb_enderecos(rua, bairro, numero, cep)
values ('Rua Augustinho', 'Vila nova', '100', '13830634')

-- Obter id do registro da tabela endereço
select currval (pg_get_serial_sequence('tb_enderecos', 'idEndereco')) into idEndereco;

-- Registro de credenciais
insert into tb_credenciais(email, senha)
values ('wellington123@gmail.com', '123456789')

-- Obter id do registro da tabela endereço
select currval (pg_get_serial_sequence('tb_credenciais', 'idCredenciais')) into idCredenciais;

-- Registro de usuários
insert into tb_usuarios(nome, sobrenome, telefone, idEndereco, idCredenciais)
values ('wellington', 'silva', '993938181', idEndereco, idCredenciais)

commit;

-- atualização de cadastro de usuário a partir da id
update tb_usuarios set nome = 'wellington', sobrenome = 'silva' where idUsuario = 1;

-- atualização do endereço do usuário a partir de sua id
update tb_enderecos set rua = '', bairro = '', numero = '', cep = '' where idUsuario = 1;

-- atualização da senha do usuario a partir de sua id
update tb_credenciais set senha = '123amovcs' where idUsuario = 1;

-- deletar cadastro do usuário (cuidado)
delete from tb_usuarios where idUsuario = 1; 


--COMPRAS

-- registrar uma compra
insert into tb_pedidos(quantidade, idUsuario, idProduto)
values (3, 1, 1);

-- atualizar uma compra
update tb_pedidos set quantidade = 5, idProduto = 1 where idPedidos  = 1;

-- excluir uma compra
delete from tb_pedidos where idPedidos = 1;

-- registrar um produto
insert into tb_produtos(nome, descricao, preco, quantidade)
values ('base', 'Base da Virginia', 99.99, 2);

-- registrar multiplos produtos
insert into tb_produtos(nome, descricao, preco, quantidade)
values 
('Lápis contorno', 'lápis de contorno preto', 10.99),
('Baton', 'Baton da boca rosa', 39.99);

-- atualização de um produto 
update set nome = 'Lápis de cilios', descricao = 'lápis de cilios preto', preco = 11.99 where idProduto = 3;