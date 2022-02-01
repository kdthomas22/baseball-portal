import axios, { AxiosRequestConfig, AxiosResponse } from 'axios'

export default class HttpUtility {
  public static get = async <T>(endPoint: string, config?: AxiosRequestConfig): Promise<AxiosResponse<T>> => {
    config = {
      url: endPoint,
      ...HttpUtility.defaultAxiosConfig,
      ...config,
      method: 'GET'
    }
    return await HttpUtility.axiosRequest<T>(config).catch(err => {
      throw err
    })
  }

  public static post = async <T>(endPoint: string, data: any, config?: AxiosRequestConfig): Promise<AxiosResponse<T>> => {
    config = {
      url: endPoint,
      ...HttpUtility.defaultAxiosConfig,
      ...config,
      method: 'POST',
      data
    }
    return HttpUtility.axiosRequest<T>(config).catch(err => {
      throw err
    })
  }

  public static put = async <T>(endPoint: string, data: any, config?: AxiosRequestConfig): Promise<AxiosResponse<T>> => {
    config = {
      url: endPoint,
      ...HttpUtility.defaultAxiosConfig,
      ...config,
      method: 'PUT',
      data
    }
    return HttpUtility.axiosRequest<T>(config).catch(err => {
      throw err
    })
  }

  public static delete = async <T>(endPoint: string, data?: any, config?: AxiosRequestConfig): Promise<AxiosResponse<T>> => {
    config = {
      url: endPoint,
      ...HttpUtility.defaultAxiosConfig,
      ...config,
      method: 'DELETE',
      data
    }
    return HttpUtility.axiosRequest<T>(config).catch(err => {
      throw err
    })
  }

  private static defaultAxiosConfig: AxiosRequestConfig = {
    headers: {
      'Content-Type': 'application/json',
      Accept: 'application/json'
    },
    withCredentials: true
  }

  private static axiosRequest = async <T>(config: any): Promise<AxiosResponse<T>> => {
    const res = (await axios(config)) as AxiosResponse<T>
    if (res.status >= 400) throw Error
    return res
  }
}
