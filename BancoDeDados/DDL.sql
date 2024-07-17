create table tb_enderecos (
id_endereco serial primary key,
rua varchar (100) not null,
bairro varchar (100) not null,
numero varchar (10) not null,
cep varchar (8) not null
);

create table tb_credenciais(
    id_credencial serial primary key,
    email varchar(50) not null,
    senha varchar(55) not null
);

create table tb_usuarios(
    id_usuario serial primary key,
    nome varchar(20) not null, 
    sobrenome varchar(20) not null,
    telefone varchar(15) not null,
    idEndereco int not null,
    idCredencial int not null

    foreign key (idEndereco) references enderecos(idEndereco),
    foreign key (idCredencial) references credenciais(idCredencial)
);

create table tb_categorias(
    id_categoria serial primary key,
    nome varchar(15)
);

create table tb_produtos(
    id_produto serial primary key,
    nome varchar(40), 
    descricao varchar(200),
    preco decimal(5,2),
    quantidade int not null,
    idCategoria int not null,

    foreign key (idCategoria) references tb_categorias(idCategoria)
);

create table tb_compras(
    id_compras serial primary key,
    quantidade int,
    idProduto int not null,
    idUsuario int not null,

    foreign key (idProduto) references tb_produtos(idProduto),
    foreign key (idUsuario) references tb_usuarios(idUsuario)
);
