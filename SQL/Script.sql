-- 2.1
SELECT 
    p.id AS pessoa_id, 
    p.nome AS pessoa_nome, 
    GROUP_CONCAT(e.evento) AS eventos
FROM tabela_pessoa p
LEFT JOIN tabela_evento e ON p.id = e.pessoa_id
GROUP BY p.id, p.nome;


-- 2.2
SELECT * FROM tabela_pessoa
WHERE nome LIKE '%Doe';

-- 2.3
INSERT INTO tabela_evento (id, evento, pessoa_id)
SELECT 5, 'Evento E', id FROM tabela_pessoa
WHERE nome = 'Lisa Romero';

-- 2.4
UPDATE tabela_evento
SET pessoa_id = (SELECT id FROM tabela_pessoa WHERE nome = 'John Doe')
WHERE evento = 'Evento D';

-- 2.5
DELETE FROM tabela_evento
WHERE evento = 'Evento B';

-- 2.6
DELETE FROM tabela_pessoa
WHERE id NOT IN (SELECT DISTINCT pessoa_id FROM tabela_evento WHERE pessoa_id IS NOT NULL);

-- 2.7
ALTER TABLE tabela_pessoa ADD COLUMN idade INT;

-- 2.8
CREATE TABLE tabela_telefone (
    id INT PRIMARY KEY,
    telefone VARCHAR(200),
    pessoa_id INT,
    FOREIGN KEY (pessoa_id) REFERENCES pessoa(id)
);

-- 2.9
CREATE UNIQUE INDEX idx_telefone_unique ON tabela_telefone(telefone);

--2.10
DROP TABLE tabela_telefone;

