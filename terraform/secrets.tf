# Store database credentials in AWS Secrets Manager
resource "aws_secretsmanager_secret" "dfs_db_credentials" {
  name = "${var.project_name}-dfs-db-credentials-${var.environment}"

  tags = {
    Name        = "${var.project_name}-dfs-db-credentials"
    Environment = var.environment
  }
}

resource "aws_secretsmanager_secret_version" "dfs_db_credentials" {
  secret_id = aws_secretsmanager_secret.dfs_db_credentials.id

  secret_string = jsonencode({
    username = var.db_master_username
    password = var.db_master_password
    host     = aws_rds_cluster.fantasy_db.endpoint
    port     = 5432
    database = aws_rds_cluster.fantasy_db.database_name
  })
}