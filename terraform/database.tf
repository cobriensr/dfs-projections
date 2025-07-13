# database.tf

# Aurora Serverless v2 cluster
resource "aws_rds_cluster" "fantasy_db" {
  cluster_identifier = "${var.project_name}-cluster-${var.environment}"

  engine         = "aurora-postgresql"
  engine_mode    = "provisioned"
  engine_version = "17.5"

  database_name   = "fantasy_sports"
  master_username = var.db_master_username
  master_password = var.db_master_password

  # Enable IAM database authentication
  iam_database_authentication_enabled = var.enable_iam_auth

  # Serverless v2 scaling configuration
  serverlessv2_scaling_configuration {
    max_capacity             = 1.0
    min_capacity             = 0.0
    seconds_until_auto_pause = 3600
  }

  # Cost optimization settings
  backup_retention_period = 7
  preferred_backup_window = "03:00-04:00"

  # Storage encryption
  storage_encrypted = true

  # Networking
  db_subnet_group_name   = aws_db_subnet_group.aurora_subnet_group.name
  vpc_security_group_ids = [aws_security_group.aurora_sg.id]

  # Skip final snapshot for dev
  skip_final_snapshot = true

  # Enable logging
  enabled_cloudwatch_logs_exports = ["postgresql"]

  tags = {
    Name        = "${var.project_name}-aurora-cluster"
    Environment = var.environment
  }
}

# Aurora Serverless v2 instance
resource "aws_rds_cluster_instance" "fantasy_db_instance" {
  identifier         = "${var.project_name}-instance-${var.environment}"
  cluster_identifier = aws_rds_cluster.fantasy_db.id
  instance_class     = "db.serverless"
  engine             = aws_rds_cluster.fantasy_db.engine
  engine_version     = aws_rds_cluster.fantasy_db.engine_version

  tags = {
    Name        = "${var.project_name}-aurora-instance"
    Environment = var.environment
  }
}