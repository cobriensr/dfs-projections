# outputs.tf

output "app_security_group_id" {
  description = "Security group ID for application servers"
  value       = aws_security_group.app_sg.id
}

output "vpc_id" {
  description = "VPC ID"
  value       = aws_vpc.main.id
}

output "public_subnet_ids" {
  description = "Public subnet IDs"
  value       = aws_subnet.public[*].id
}

output "private_subnet_ids" {
  description = "Private subnet IDs"
  value       = aws_subnet.private[*].id
}

output "s3_bucket_name" {
  description = "Name of the S3 bucket for data storage"
  value       = aws_s3_bucket.data_bucket.id
}

output "s3_bucket_arn" {
  description = "ARN of the S3 bucket"
  value       = aws_s3_bucket.data_bucket.arn
}

output "aurora_cluster_endpoint" {
  description = "Aurora cluster endpoint"
  value       = aws_rds_cluster.fantasy_db.endpoint
}

output "aurora_reader_endpoint" {
  description = "Aurora reader endpoint"
  value       = aws_rds_cluster.fantasy_db.reader_endpoint
}

output "aurora_cluster_resource_id" {
  description = "Aurora cluster resource ID (needed for IAM auth)"
  value       = aws_rds_cluster.fantasy_db.cluster_resource_id
}

output "db_secret_name" {
  description = "Name of the secret containing database credentials"
  value       = aws_secretsmanager_secret.dfs_db_credentials.name
  sensitive   = true
}

output "db_secret_arn" {
  description = "ARN of the secret containing database credentials"
  value       = aws_secretsmanager_secret.dfs_db_credentials.arn
  sensitive   = true
}

output "app_iam_role_arn" {
  description = "IAM role ARN for application database access"
  value       = aws_iam_role.app_db_access_role.arn
}

output "connection_string" {
  description = "PostgreSQL connection string (without password)"
  value       = "Host=${aws_rds_cluster.fantasy_db.endpoint};Database=${aws_rds_cluster.fantasy_db.database_name};Username=${var.db_master_username};Password=<check-secrets-manager>"
  sensitive   = true
}

output "iam_connection_instructions" {
  description = "Instructions for connecting with IAM authentication"
  value       = var.enable_iam_auth ? "To connect with IAM auth: 1) Create DB user with 'CREATE USER myuser WITH LOGIN;' 2) Grant 'rds_iam' role with 'GRANT rds_iam TO myuser;' 3) Use IAM token as password" : "IAM authentication is disabled"
}