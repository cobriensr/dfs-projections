# # Create a bastion EC2 instance for SSM access
# resource "aws_instance" "ssm_bastion" {
#   count = var.enable_ssm_endpoint ? 1 : 0

#   ami                    = data.aws_ami.amazon_linux_2.id
#   instance_type          = "t3.micro"
#   vpc_security_group_ids = [aws_security_group.app_sg.id]
#   iam_instance_profile   = aws_iam_instance_profile.ssm_instance_profile[0].name

#   # No key pair needed - access via SSM

#   user_data = <<-EOF
#     #!/bin/bash
#     # Install PostgreSQL client
#     amazon-linux-extras install postgresql14 -y
    
#     # Install AWS CLI v2
#     curl "https://awscli.amazonaws.com/awscli-exe-linux-x86_64.zip" -o "awscliv2.zip"
#     unzip awscliv2.zip
#     ./aws/install
    
#     # Install Session Manager plugin
#     curl "https://s3.amazonaws.com/session-manager-downloads/plugin/latest/linux_64bit/session-manager-plugin.rpm" -o "session-manager-plugin.rpm"
#     yum install -y session-manager-plugin.rpm
#   EOF

#   tags = {
#     Name = "${var.project_name}-ssm-bastion"
#   }
# }

# # Instance profile for SSM bastion
# resource "aws_iam_instance_profile" "ssm_instance_profile" {
#   count = var.enable_ssm_endpoint ? 1 : 0

#   name = "${var.project_name}-ssm-instance-profile"
#   role = aws_iam_role.ssm_session_role[0].name
# }