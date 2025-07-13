# iam.tf

# IAM role for application to access database
resource "aws_iam_role" "app_db_access_role" {
  name = "${var.project_name}-app-db-access-role"

  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Action = "sts:AssumeRole"
        Effect = "Allow"
        Principal = {
          Service = [
            "lambda.amazonaws.com",
            "ecs-tasks.amazonaws.com",
            "ec2.amazonaws.com"
          ]
        }
      }
    ]
  })

  tags = {
    Name = "${var.project_name}-app-db-access-role"
  }
}

# IAM policy for RDS IAM authentication
resource "aws_iam_policy" "rds_iam_auth_policy" {
  name        = "${var.project_name}-rds-iam-auth-policy"
  description = "Allow IAM authentication to RDS"

  policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Effect = "Allow"
        Action = [
          "rds-db:connect"
        ]
        Resource = "arn:aws:rds-db:${var.aws_region}:${data.aws_caller_identity.current.account_id}:dbuser:${aws_rds_cluster.fantasy_db.cluster_resource_id}/*"
      }
    ]
  })
}

# Attach RDS IAM auth policy to role
resource "aws_iam_role_policy_attachment" "app_rds_iam_auth" {
  policy_arn = aws_iam_policy.rds_iam_auth_policy.arn
  role       = aws_iam_role.app_db_access_role.name
}

# Attach basic Lambda execution policy (if using Lambda)
resource "aws_iam_role_policy_attachment" "lambda_basic_execution" {
  policy_arn = "arn:aws:iam::aws:policy/service-role/AWSLambdaBasicExecutionRole"
  role       = aws_iam_role.app_db_access_role.name
}

# Attach VPC execution policy (if Lambda needs VPC access)
resource "aws_iam_role_policy_attachment" "lambda_vpc_execution" {
  policy_arn = "arn:aws:iam::aws:policy/service-role/AWSLambdaVPCAccessExecutionRole"
  role       = aws_iam_role.app_db_access_role.name
}

# EC2 instance profile for database access (if using EC2)
resource "aws_iam_instance_profile" "app_instance_profile" {
  name = "${var.project_name}-app-instance-profile"
  role = aws_iam_role.app_db_access_role.name
}

# IAM role for Systems Manager session
resource "aws_iam_role" "ssm_session_role" {
  count = var.enable_ssm_endpoint ? 1 : 0

  name = "${var.project_name}-ssm-session-role"

  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Action = "sts:AssumeRole"
        Effect = "Allow"
        Principal = {
          Service = "ec2.amazonaws.com"
        }
      }
    ]
  })

  tags = {
    Name = "${var.project_name}-ssm-session-role"
  }
}

# Attach SSM managed instance core policy
resource "aws_iam_role_policy_attachment" "ssm_managed_instance_core" {
  count = var.enable_ssm_endpoint ? 1 : 0

  policy_arn = "arn:aws:iam::aws:policy/AmazonSSMManagedInstanceCore"
  role       = aws_iam_role.ssm_session_role[0].name
}