### Run in Terminal
```shell
ssh -i icrest-abinitio-training.pem ec2-user@ec2-43-216-59-160.ap-southeast-5.compute.amazonaws.com

```
### Install Podman
```shell
sudo dnf install -y podman


```
### Replace Docker with an Alias
```shell
echo "alias docker=podman" >> ~/.bashrc
source ~/.bashrc
```

### Enable Docker Compose (Optional)

If you need to run docker-compose.yml files, you can install the podman-compose wrapper. 
```shell
sudo dnf install -y python3-pip
pip3 install podman-compose

```



