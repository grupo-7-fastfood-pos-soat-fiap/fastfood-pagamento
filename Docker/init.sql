
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE public.situacoes_pagamentos ( 
   id INT NOT NULL, 
   nome varchar(50) NOT NULL, 
   CONSTRAINT situacoes_pagamentos_pkey PRIMARY KEY (id) 
);

CREATE TABLE public.pagamentos ( 
   id uuid NOT NULL, 
   pedido_id uuid NOT NULL,
   situacao_id INT NOT NULL, 
   valor money NOT NULL, 
   qr_code varchar(300) NOT NULL, 
   CONSTRAINT pagamentos_pkey PRIMARY KEY (id), 
   CONSTRAINT pagamentos_situacoes_fk FOREIGN KEY (situacao_id) REFERENCES public.situacoes_pagamentos(id)
);

INSERT INTO public.situacoes_pagamentos (id, nome) VALUES 
   (0, 'Pendente'),
   (1, 'Aprovado'),
   (2, 'Recusado');
