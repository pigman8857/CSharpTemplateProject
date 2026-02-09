using System;

namespace JoiDelivery.Application.Settings;

public class ServerSettings
{
  public string ServerName { get; set; }
  public int Port { get; set; }
}

public class DatabaseSettings
{
  public string DefaultConnection { get; set; }
  public int CommandTimeout { get; set; }
}

