# variables.tf
variable "aws_region" {
  description = "AWS region for resources"
  type        = string
  default     = "us-east-1"
}

variable "project_name" {
  description = "Project name for resource naming"
  type        = string
  default     = "fantasy-sports-platform"
}

variable "environment" {
  description = "Environment name"
  type        = string
  default     = "dev"
}

variable "db_master_username" {
  description = "Master username for Aurora database"
  type        = string
  sensitive   = true
}

variable "db_master_password" {
  description = "Master password for Aurora database"
  type        = string
  sensitive   = true
}

variable "allowed_ip_addresses" {
  description = "List of IP addresses allowed to connect to the database"
  type        = list(string)
  default     = []
}

variable "enable_local_access" {
  description = "Enable access from your current IP address"
  type        = bool
  default     = true
}

variable "enable_iam_auth" {
  description = "Enable IAM database authentication"
  type        = bool
  default     = true
}

variable "enable_ssm_endpoint" {
  description = "Enable VPC endpoint for Systems Manager"
  type        = bool
  default     = true
}

variable "access_key_id" {
  description = "AWS access key ID"
  type        = string
  sensitive   = true
}

variable "secret_access_key" {
  description = "AWS secret access key"
  type        = string
  sensitive   = true
}

variable "create_nat_gateway" {
  description = "Whether to create NAT Gateway"
  type        = bool
  default     = false
}