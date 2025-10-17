docker rm -f jellyfin
docker run -d --name jellyfin -p 8096:8096 jellyfin/jellyfin
