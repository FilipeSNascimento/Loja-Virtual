--CONSULTA E MANIPULAÇÂO

-- Consultar nome e sobrenome
select nome, sobrenome from tb_usuarios;

-- Unir nome e sobrenome
select concat(nome, ' ', sobrenome) as nome_completo from tb_usuarios;

-- Renomear as propriedades da tabela
select 
    nome as primeiro_nome,
    sobrenome as ultimo_nome 
from tb_usuarios;

-- Ordenar de maneira decrescente
select email from tb_credenciais order by email desc;

-- Filtrar
select nome, sobrenome from tb_usuarios where nome = 'Lucas';

-- Contagem
select count(*) as total_usuarios from tb_usuarios where bairro = 'Limoeiro' group by rua;

-- Consulta por palavra-chave
select concat(nome, ' ', sobrenome) as nome_completo from tb_usuarios where nome like '%lu%';

-- Paginação
select nome, sobrenome from tb_usuarios limit 10 offset 0;
select nome, sobrenome from tb_usuarios limit 10 offset 10;
select nome, sobrenome from tb_usuarios limit 10 offset 20;
