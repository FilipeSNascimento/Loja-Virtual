--CADASTRO DE USUÁRIO
begin;

-- Registro de endereço
insert into tb_enderecos(rua, bairro, numero, cep)
values ('Rua Augustinho', 'Vila nova', '100', '13830634')

-- Obter id do registro da tabela endereço
select currval (pg_get_serial_sequence('tb_enderecos', 'id_endereco')) into id_endereco;

-- Registro de credenciais
insert into tb_credenciais(email, senha)
values ('wellington123@gmail.com', '123456789')

-- Obter id do registro da tabela endereço
select currval (pg_get_serial_sequence('tb_credenciais', 'id_credenciais')) into id_credenciais;

-- Registro de usuários
insert into tb_usuarios(nome, sobrenome, telefone, id_endereco, id_credenciais)
values ('wellington', 'silva', '993938181', id_endereco, id_credenciais)

commit;

-- atualização de cadastro de usuário a partir da id
update tb_usuarios set nome = 'wellington', sobrenome = 'silva' where id_usuario = 1;

-- atualização do endereço do usuário a partir de sua id
update tb_enderecos set rua = '', bairro = '', numero = '', cep = '' where id_usuario = 1;

-- atualização da senha do usuario a partir de sua id
update tb_credenciais set senha = '123amovcs' where id_usuario = 1;

-- deletar cadastro do usuário (cuidado)
delete from tb_usuarios where id_usuario = 1; 


--COMPRAS

-- registrar uma compra
insert into tb_compras(quantidade, id_usuario, id_produto)
values (3, 1, 1);

-- atualizar uma compra
update tb_compras set quantidade = 5, id_produto = 1 where id_compra  = 1;

-- excluir uma compra
delete from tb_compras where id_pedidos = 1;

-- registrar um produto
insert into tb_produtos(nome, descricao, preco, quantidade)
values ('base', 'Base da Virginia', 99.99, 2);

-- registrar multiplos produtos
insert into tb_produtos(nome, descricao, preco, quantidade)
values 
('Lápis contorno', 'lápis de contorno preto', 10.99),
('Baton', 'Baton da boca rosa', 39.99);

-- atualização de um produto 
update set nome = 'Lápis de cilios', descricao = 'lápis de cilios preto', preco = 11.99 where id_produto = 3;