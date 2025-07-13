# data.tf

# Data source for current AWS account
data "aws_caller_identity" "current" {}

# Get current IP address if local access is enabled
data "http" "myip" {
  count = var.enable_local_access ? 1 : 0
  url   = "https://checkip.amazonaws.com"
}

# Get available AZs
data "aws_availability_zones" "available" {
  state = "available"
}

# Data source for latest Amazon Linux 2 AMI
data "aws_ami" "amazon_linux_2" {
  most_recent = true
  owners      = ["amazon"]

  filter {
    name   = "name"
    values = ["amzn2-ami-hvm-*-x86_64-gp2"]
  }

  filter {
    name   = "virtualization-type"
    values = ["hvm"]
  }
}