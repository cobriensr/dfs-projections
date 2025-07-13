# s3.tf

# S3 bucket for CSV storage
resource "aws_s3_bucket" "data_bucket" {
  bucket = "${var.project_name}-data-${var.environment}-${data.aws_caller_identity.current.account_id}"

  tags = {
    Name        = "${var.project_name}-data"
    Environment = var.environment
  }
}

# Enable versioning for data protection
resource "aws_s3_bucket_versioning" "data_bucket_versioning" {
  bucket = aws_s3_bucket.data_bucket.id

  versioning_configuration {
    status = "Enabled"
  }
}

# Block public access for security
resource "aws_s3_bucket_public_access_block" "data_bucket_pab" {
  bucket = aws_s3_bucket.data_bucket.id

  block_public_acls       = true
  block_public_policy     = true
  ignore_public_acls      = true
  restrict_public_buckets = true
}

# S3 bucket for organizing data
resource "aws_s3_object" "folder_structure" {
  for_each = toset([
    "raw-data/",
    "raw-data/historical/",
    "raw-data/historical/baseball/2024/",
    "raw-data/historical/football/2024/",
    "raw-data/historical/college-football/2024/",
    "processed-data/",
    "processed-data/historical/baseball/2024/",
    "processed-data/historical/football/2024/",
    "processed-data/historical/college-football/2024/"
  ])

  bucket = aws_s3_bucket.data_bucket.id
  key    = each.value
}