FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env 
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore
# Basically to pull down the packages in here that
# we need to build our image

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PlatformService.dll"]



# Notes: 
# 1.FROM
# A FROM statement defines which image to download and start from. 
# It must be the first command in your Dockerfile. 
# A Dockerfile can have multiple FROM statements which means the 
# Dockerfile produces more than one image.

# 2. WORKDIR:
# As the name suggests, WORKDIR sets the directory that the 
# container starts in. Its main purpose is to set the working 
# directory for all future Dockerfile commands.
# Example:
# WORKDIR /directory-name

# 3. RUN:
# The RUN statement defines running a command through the shell, 
# waiting for it to finish, and saving the result. It tells what 
# process will be running inside the container at the run time.

# 4. ENTRYPOINT:
# It specifies the starting of the expression to use when starting
# your container. Simply ENTRYPOINT specifies the start of the 
# command to run. If your container acts as a command-line program, 
# you can use ENTRYPOINT.
# Example:
# ENTRYPOINT ["/start.sh"]

# 5. CMD:
# CMD specifies the whole command to run. 
# We can say CMD is the default argument passed 
# into the ENTRYPOINT. The main purpose of 
# the CMD command is to launch the software 
# required in a container.

# Example:

# CMD [“program-foreground”]
# CMD [“executable”, “program1”, “program2”]

# Note: If you have both ENVIRONMENT and CMD, they are combined together.