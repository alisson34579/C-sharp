Perfeito — vou explicar passo a passo (curto e direto) para rodar um servidor Jellyfin usando Docker seguindo a lousa da foto. Vou assumir que você está numa máquina Linux/Windows com Docker instalado.


---

0. Pré-requisito

Docker instalado e funcionando (docker --version).

Uma pasta no disco com seus vídeos (ex: /home/usuario/media ou C:\Users\Você\Media).



---

1 — Matar todos os containers em execução

(Pára tudo que estiver rodando)

docker ps -q | xargs -r docker kill

ou (mais gentil)

docker stop $(docker ps -q)

> -q retorna só os IDs; xargs -r evita erro se não houver nada.




---

2 — Remover todos os containers

(para limpar)

docker ps -aq | xargs -r docker rm -f

> -f força a remoção.




---

3 — Baixar e rodar o Jellyfin com Docker

Crie pastas para configurar persistência (config, cache, media). Exemplo Linux:

mkdir -p ~/jellyfin/config ~/jellyfin/cache ~/jellyfin/media
# coloque seus vídeos dentro de ~/jellyfin/media

Rodar o container:

docker run -d \
  --name jellyfin \
  -p 8096:8096 \
  -v ~/jellyfin/config:/config \
  -v ~/jellyfin/cache:/cache \
  -v ~/jellyfin/media:/media \
  --restart unless-stopped \
  jellyfin/jellyfin:latest

-p 8096:8096 mapeia a porta padrão do Jellyfin (web sem HTTPS).

ajuste os caminhos ~/jellyfin/... conforme seu SO.



---

4 — Criar usuários (pela interface web)

1. No navegador da própria máquina acesse: http://localhost:8096.


2. Siga o assistente de instalação (idioma, administrador inicial etc.).


3. Para criar usuários depois: Menu (canto superior direito) → Dashboard → Users → Add User.
Crie os usuários sugeridos da lousa, por exemplo:



usuário: aluno, senha: mpe

usuário: adm, senha: admin123


(Se já criou um admin no primeiro setup, você pode criar aluno via Dashboard)


---

5 — Disponibilizar um vídeo

Coloque os arquivos de vídeo na pasta que montou em /media (ex: ~/jellyfin/media/Filmes/).

No Jellyfin: Dashboard → Libraries → Add Library → escolha tipo (Movies/Videos) e a pasta /media (ou subpasta).

Após criar, clique em Scan Library Files ou aguarde a varredura automática — o vídeo ficará disponível para todos os usuários.



---

6 — Consultar seu IP (para acessar de outra máquina)

Linux/macOS:


ip addr show
# ou: hostname -I

Windows (no cmd):


ipconfig

Procure o endereço IPv4 da interface (ex.: 10.20.30.240).
A lousa mostra algo parecido: 10.20.30.240


---

7 — Abrir porta no firewall (se necessário)

Linux com ufw:


sudo ufw allow 8096/tcp

Windows: abra o Firewall do Windows e permita a porta TCP 8096 para entrada.



---

8 — Pedir para um colega acessar

Diga ao colega para abrir no navegador:

http://<seu_IP>:8096

Exemplo: http://10.20.30.240:8096
Eles poderão entrar com os usuários criados (aluno, adm).


---

Dicas rápidas / resolução de problemas

Se não abrir, verifique: docker logs jellyfin para erros.

Se a porta 8096 já estiver em uso, pare o serviço que está usando ou mude para outra porta -p 8097:8096.

Para remover apenas o jellyfin antigo: docker rm -f jellyfin antes de recriar.

Para atualizar: docker pull jellyfin/jellyfin:latest e recrie o container.



---

Se quiser, eu já deixo os comandos prontos adaptados pro seu caminho (Linux ou Windows) — me diga qual SO e onde estão os vídeos que você usa. Quer que eu gere esse script pronto?

